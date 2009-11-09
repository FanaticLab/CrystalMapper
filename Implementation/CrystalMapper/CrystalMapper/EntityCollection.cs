using System;

using CoreSystem.Collections;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Collections.Specialized;


namespace CrystalMapper
{
    public delegate void Associate<TEntity>(TEntity entity)
    where TEntity : Entity<TEntity>, new();

    public delegate void DeAssociate<TEntity>(TEntity entity)
    where TEntity : Entity<TEntity>, new();

    public delegate TEntity[] GetChildren<TEntity>()
    where TEntity : Entity<TEntity>, new();

    public class EntityCollection<TEntity> : ICollection<TEntity>, INotifyCollectionChanged
        where TEntity : Entity<TEntity>, new()
    {

        #region Private Members

        #region Variables

        private readonly Entity parentEntity;

        private readonly DispatchEvent collectionChangedEvent = new DispatchEvent();

        private readonly DispatchedObservableCollection<TEntity> collection = new DispatchedObservableCollection<TEntity>();

        #endregion

        #region Relationship Function Members

        private readonly Associate<TEntity> Associate;

        private readonly DeAssociate<TEntity> DeAssociate;

        private readonly GetChildren<TEntity> GetChildren;

        #endregion

        #endregion

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

        public EntityCollection(Entity parentEntity, Associate<TEntity> associate, DeAssociate<TEntity> deAssociate, GetChildren<TEntity> getChildren)
        {
            this.parentEntity = parentEntity;
            this.Associate = associate;
            this.DeAssociate = deAssociate;
            this.GetChildren = getChildren;

            this.collection.CollectionChanged += new NotifyCollectionChangedEventHandler(delegate(object sender, NotifyCollectionChangedEventArgs e)
                                                                                                  {
                                                                                                      this.OnCollectionChanged(e);
                                                                                                  });
        }

        public void Load()
        {
            this.AddRange(this.GetChildren());
        }

        public void Add(TEntity entity)
        {
            this.Associate(entity);
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

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.collectionChangedEvent.Fire(this, e);
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
            add { this.collectionChangedEvent.Add(value); }
            remove { this.collectionChangedEvent.Remove(value); }
        }

        #endregion
    }
}
