using System;

using CoreSystem.Collections;
using System.Collections.Generic;
using System.Collections;


namespace CrystalMapper
{
    public delegate void Associate<TEntity>(TEntity entity)
    where TEntity : Entity<TEntity>, new();

    public delegate void DeAssociate<TEntity>(TEntity entity)
    where TEntity : Entity<TEntity>, new();

    public delegate TEntity[] GetChildren<TEntity>()
    where TEntity : Entity<TEntity>, new();
    
    public class EntityCollection<TEntity> : IEnumerable<TEntity>
        where TEntity : Entity<TEntity>, new()
    {
        private Entity parentEntity;        
        List<TEntity> entityList = new List<TEntity>();

        private Associate<TEntity> Associate;
        private DeAssociate<TEntity> DeAssociate;
        private GetChildren<TEntity> GetChildren;


        public EntityCollection(Entity parentEntity, Associate<TEntity> associate, DeAssociate<TEntity> deAssociate, GetChildren<TEntity> getChildren)
        {
            this.parentEntity = parentEntity;
            this.Associate = associate;
            this.DeAssociate = deAssociate;
            this.GetChildren = getChildren;
        }              

        public void Add(TEntity entity)
        {
            if (!this.entityList.Contains(entity))
            {
                this.entityList.Add(entity);
                this.Associate(entity);
            }

            if (!this.parentEntity.Children.Contains(entity))
                this.parentEntity.Children.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            if (this.entityList.Contains(entity))
            {
                this.entityList.Add(entity);
                this.DeAssociate(entity);
            }

            if (this.parentEntity.Children.Contains(entity))
                this.parentEntity.Children.Add(entity);
        }

        public void Load()
        {
            this.entityList.AddRange(this.GetChildren());
        }

        #region IEnumerable<TChild> Members

        public IEnumerator<TEntity> GetEnumerator()
        {
            foreach (TEntity entity in this.entityList)
                yield return entity;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
