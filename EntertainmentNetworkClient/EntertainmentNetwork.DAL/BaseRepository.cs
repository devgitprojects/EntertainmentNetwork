
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.DAL
{
    public abstract class BaseRepository<T> where T : IBaseModel
    {
        /// <summary>
        /// Performs cast to list. Subscribes to PropertyChanged for changing flag IsChanged to true if property changes occur
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        protected List<T> CastToList(Array entities)
        {
            return entities == null ? (List<T>)Enumerable.Empty<T>() : entities.Cast<T>().ToList();
        }

        /// <summary>
        /// Sets flag ISchanged to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Entity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IBaseModel entity = sender as IBaseModel;
            if (entity != null)
            {
                entity.IsChanged = true;
            }
        }

        public void Update(T target, T source)
        {
            target.Update(source);
            target.IsChanged = false;
        }

        protected void Update(IEnumerable<T> target, IEnumerable<T> source)
        {
            foreach (T entity in target)
            {
                T updated = entity.IsNew
                    ? source.FirstOrDefault(x => !target.Contains(x))
                    : source.FirstOrDefault(x => x.GetId() == entity.GetId());

                if (updated != null)
                {
                    entity.Update(updated);
                }

                entity.IsChanged = false;
            }
        }
    }
}
