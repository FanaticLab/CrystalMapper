
using CoreSystem.Data;
using System.Data.Common;
using CrystalMapper.Data;
using System.Collections.Generic;
using System.ComponentModel;
using CoreSystem.Collections;
using System;

namespace CrystalMapper
{
    public abstract class Entity : INotifyPropertyChanged
    {
        #region Events

        private DispatchEvent propertyChanged = new DispatchEvent();

        private DispatchEvent propertyChanging = new DispatchEvent();

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { propertyChanged.Add(value); }
            remove { propertyChanged.Remove(value); }
        }

        public event PropertyChangingEventHandler PropertyChanging
        {
            add { propertyChanging.Add(value); }
            remove { propertyChanging.Remove(value); }
        }

        #endregion

        protected List<Entity> Parents { get; private set; }

        public List<Entity> Children { get; private set; }

        public PersistedStatus PersistedStatus { get; private set; }

        public bool IsParentsPersisted
        {
            get
            {
                foreach (Entity parent in this.Parents)
                    if (parent.PersistedStatus == PersistedStatus.New)
                        return false;

                return true;
            }
        }

        public bool IsChildrenRemoved
        {
            get
            {
                foreach (Entity child in this.Children)
                    if (child.PersistedStatus == PersistedStatus.Dirty || child.PersistedStatus == PersistedStatus.Updated)
                        return false;

                return true;
            }
        }

        protected virtual void OnPropertyChanging(PropertyChangingEventArgs e)
        {
            this.propertyChanging.Fire(this, e);
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PersistedStatus != PersistedStatus.New && this.PersistedStatus != PersistedStatus.Deleted)
                this.PersistedStatus = PersistedStatus.Dirty;

            this.propertyChanged.Fire(this, e);
        }

        public Entity()
        {
            this.Parents = new List<Entity>();
            this.Children = new List<Entity>();
        }

        public virtual void Read(DbDataReader reader)
        {
            this.PersistedStatus = PersistedStatus.Updated;
        }

        public abstract bool Update(DataContext dataContext);

        public abstract bool Create(DataContext dataContext);

        public abstract bool Delete(DataContext dataContext);

        public bool Create()
        {
            using (DataContext dataContext = new DataContext())
            {
                dataContext.BeginTransaction();
                bool retVal = this.Create(dataContext);
                dataContext.CommitTransaction();

                return retVal;
            }

        }

        public bool Update()
        {            
            using (DataContext dataContext = new DataContext())
            {
                dataContext.BeginTransaction();
                bool retVal = this.Update(dataContext);
                dataContext.CommitTransaction();
                return retVal;
            }
        }

        public bool Delete()
        {           
            using (DataContext dataContext = new DataContext())
            {
                dataContext.BeginTransaction();
                bool retVal = this.Delete(dataContext);
                dataContext.CommitTransaction();

                return retVal;
            }
        }

        public void DeleteWithChildren()
        {
            Entity.Delete(new Entity[] { this });
        }

        public void SaveChanges()
        {
            Entity.SaveChanges(new Entity[] { this });
        }

        public void SaveChanges(DataContext dataContext)
        {
            Entity.SaveChanges(new Entity[] { this }, dataContext);
        }

        public static void Delete(IEnumerable<Entity> entities)
        {
            using (DataContext dataContext = new DataContext())
            {
                dataContext.BeginTransaction();

                Entity.Delete(entities, dataContext);

                dataContext.CommitTransaction();
            }
        }

        public static void Delete(IEnumerable<Entity> entities, DataContext dataContext)
        {
            Entity[] deletableEntities;
            List<Entity> visited = new List<Entity>();
            List<Entity> deletableEntityList = new List<Entity>();

            foreach (Entity entity in DeletableEntities(entities, visited))
                if (!deletableEntityList.Contains(entity))
                    deletableEntityList.Add(entity);

            deletableEntities = deletableEntityList.ToArray();
            deletableEntityList.Clear();

            while (deletableEntities != null && deletableEntities.Length > 0)
            {
                for (int i = 0; i < deletableEntities.Length; i++)
                {
                    Entity entity = deletableEntities[i];
                    if (entity.IsChildrenRemoved)
                    {
                        bool isDeleted = false;
                        switch (entity.PersistedStatus)
                        {
                            case PersistedStatus.Dirty:
                            case PersistedStatus.Updated:
                                isDeleted = entity.Delete(dataContext);
                                break;
                            case PersistedStatus.New:

                                throw new InvalidOperationException(String.Format("Entity: '{0}' persisted status does not suppose to be '{1}'", entity, entity.PersistedStatus));
                            default:
                                throw new InvalidOperationException(String.Format("Unrecognized PersistedStatus: '{0}'", entity.PersistedStatus));
                        }

                        if (!isDeleted)
                            throw new InvalidOperationException(string.Format("Unable to delete Entity: '{0}'", entity));

                        entity.PersistedStatus = PersistedStatus.Deleted;
                    }
                    else
                        deletableEntityList.Add(entity);
                }

                deletableEntities = deletableEntityList.ToArray();
                deletableEntityList.Clear();
            }
        }

        public static void SaveChanges(IEnumerable<Entity> entities)
        {
            using (DataContext dataContext = new DataContext())
            {
                dataContext.BeginTransaction();

                Entity.SaveChanges(entities, dataContext);

                dataContext.CommitTransaction();
            }
        }

        public static void SaveChanges(IEnumerable<Entity> entities, DataContext dataContext)
        {
            Entity[] dirtyEntities;
            List<Entity> visited = new List<Entity>();
            List<Entity> dirtyEntityList = new List<Entity>();

            foreach (Entity entity in DirtyEntities(entities, visited))
                if (!dirtyEntityList.Contains(entity))
                    dirtyEntityList.Add(entity);

            dirtyEntities = dirtyEntityList.ToArray();
            dirtyEntityList.Clear();

            while (dirtyEntities != null && dirtyEntities.Length > 0)
            {
                for (int i = dirtyEntities.Length - 1; i >= 0; i--)
                {
                    Entity entity = dirtyEntities[i];
                    if (entity.IsParentsPersisted)
                    {
                        bool isChangesSaved = false;
                        switch (entity.PersistedStatus)
                        {
                            case PersistedStatus.New:
                                isChangesSaved = entity.Create(dataContext);
                                break;
                            case PersistedStatus.Dirty:
                                isChangesSaved = entity.Update(dataContext);
                                break;
                            case PersistedStatus.Deleted:
                            case PersistedStatus.Updated:
                                throw new InvalidOperationException(String.Format("Entity: '{0}' persisted status does not suppose to be '{1}'", entity, entity.PersistedStatus));
                            default:
                                throw new InvalidOperationException(String.Format("Unrecognized PersistedStatus: '{0}'", entity.PersistedStatus));
                        }

                        if (!isChangesSaved)
                            throw new InvalidOperationException(string.Format("Unable to save changes for Entity: '{0}'", entity));

                        entity.PersistedStatus = PersistedStatus.Updated;
                    }
                    else
                        dirtyEntityList.Add(entity);
                }

                dirtyEntities = dirtyEntityList.ToArray();
                dirtyEntityList.Clear();
            }
        }

        private static IEnumerable<Entity> DirtyEntities(IEnumerable<Entity> enities, List<Entity> visited)
        {
            foreach (Entity entity in enities)
            {
                if (!visited.Contains(entity))
                {
                    visited.Add(entity);

                    foreach (Entity parentEntity in DirtyEntities(entity.Parents, visited))
                        yield return parentEntity;

                    foreach (Entity childEntity in DirtyEntities(entity.Children, visited))
                        yield return childEntity;

                    if (entity.PersistedStatus == PersistedStatus.Dirty || entity.PersistedStatus == PersistedStatus.New)
                        yield return entity;
                }
            }
        }

        private static IEnumerable<Entity> DeletableEntities(IEnumerable<Entity> entities, List<Entity> visited)
        {
            foreach (Entity entity in entities)
            {
                if (!visited.Contains(entity))
                {
                    visited.Add(entity);

                    foreach (Entity childEntity in DeletableEntities(entity.Children, visited))
                        yield return childEntity;

                    if (entity.PersistedStatus == PersistedStatus.Dirty || entity.PersistedStatus == PersistedStatus.Updated)
                        yield return entity;
                }
            }
        }
    }
}
