using System;

using CoreSystem.Collections;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Collections.Specialized;


namespace CrystalMapper.Generic.Collection
{
    public delegate void Associate<TEntity>(TEntity entity)
    where TEntity : Entity<TEntity>, new();

    public delegate void DeAssociate<TEntity>(TEntity entity)
    where TEntity : Entity<TEntity>, new();

    public delegate TEntity[] GetChildren<TEntity>()
    where TEntity : Entity<TEntity>, new();
        
    public class EntityCollection<TEntity> : ICollection<TEntity>, INotifyCollectionChanged, ICollection, INotifyPropertyChanged
        where TEntity : Entity<TEntity>, new()
    {
        #region Private Members
       
        #region Relationship Function Members

        private readonly Associate<TEntity> Associate;

        private readonly DeAssociate<TEntity> DeAssociate;

        private readonly GetChildren<TEntity> GetChildren;

        #endregion
        
        #region Variables        

        private readonly Entity parentEntity;

        private readonly DispatchedObservableCollection<TEntity> collection = new DispatchedObservableCollection<TEntity>();

        #endregion

        #endregion

        public bool IsLoaded { get; private set; }

        public TEntity this[int index]
        {
            get { return this.collection[index]; }
        }

        public int Count
        {
            get { return this.collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public EntityCollection(Entity parentEntity
                                , Associate<TEntity> associate
                                , DeAssociate<TEntity> deAssociate
                                , GetChildren<TEntity> getChildren)
        {
            this.parentEntity = parentEntity;
            this.Associate = associate;
            this.DeAssociate = deAssociate;
            this.GetChildren = getChildren;
            this.collection.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
            {
                this.OnProperyChanged(new PropertyChangedEventArgs("Count"));
            };
        }               

        public void Load()
        {
            if (!this.IsLoaded)
            {
                TEntity[] children = this.GetChildren();
                if (children != null)
                    foreach (TEntity entity in children)
                        this.AddOnly(entity);
                this.IsLoaded = true;
            }            
        }

        public void Add(TEntity entity)
        {   
            this.Associate(entity);
            this.AddOnly(entity);
        }
                
        public void AddOnly(TEntity entity)
        {
            if (!this.collection.Contains(entity))
            {
                this.parentEntity.Children.Add(entity);
                this.collection.Add(entity);
            }  
        }

        public bool Remove(TEntity entity)
        {
            if (this.collection.Contains(entity))
            {
                this.parentEntity.Children.Remove(entity);
                this.DeAssociate(entity);
                this.collection.Remove(entity);

                return true;
            }

            return false;
        }

        public bool RemoveOnly(TEntity entity)
        {
            if (this.collection.Contains(entity))
            {
                this.parentEntity.Children.Remove(entity);               
                this.collection.Remove(entity);
                return true;
            }

            return false;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                this.Add(entity);
        }

        public bool Contains(TEntity entity)
        {
            return this.collection.Contains(entity);
        }

        public void Clear()
        {
            foreach (TEntity entity in this.collection)
                this.parentEntity.Children.Remove(entity);

            this.collection.Clear();
        }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            this.collection.CopyTo(array, arrayIndex);
        }

        #region IEnumerable<TChild> Members

        public IEnumerator<TEntity> GetEnumerator()
        {
            foreach (TEntity entity in this.collection)
                yield return entity;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region INotifyCollectionChanged Members

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { this.collection.CollectionChanged += value; }
            remove { this.collection.CollectionChanged -= value; }
        }

        #endregion

        #region ICollection Members

        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)this.collection).CopyTo(array, index);
        }

        bool ICollection.IsSynchronized
        {
            get { return ((ICollection)this.collection).IsSynchronized; }
        }

        object ICollection.SyncRoot
        {
            get { return ((ICollection)this.collection).SyncRoot; }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected virtual void OnProperyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
    }
}
