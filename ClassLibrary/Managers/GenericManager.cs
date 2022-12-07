using Data_Class_Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Class_Library.Managers
{
    /// <summary>
    /// Base class for a REST Manager, with default overridable implementations of CRUD.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericManager<T> where T : class, IIdentity, IValidate
    {


        #region Properties
        /// <summary>
        /// Provide an abstract dictionary, to be overriden in the derived classes.
        /// </summary>
        public abstract Dictionary<int, T> Values { get; set; }
        /// <summary>
        /// Provide an abstract integer, to be overriden, and used in generating ids for new objects.
        /// </summary>
        public abstract int NextIdentity { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Method that retrieves all the values of the Collection.
        /// </summary>
        /// <returns>List of types T.</returns>
        public List<T> Get()
        {
            return Values.Values.ToList();
        }

        /// <summary>
        /// Method that tries to get an object with the given id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Object of type T.</returns>
        /// <exception cref="KeyNotFoundException">If an object isn't found with the given type, throw an exception.</exception>
        public T GetByIdentity(int id)
        {
            if (Values.ContainsKey(id))
                return Values[id];

            throw new KeyNotFoundException($"Key ({id}) not found for {typeof(T).Name}");

        }

        /// <summary>
        /// Method that tries to add an object.
        /// </summary>
        /// <returns>Added object.</returns>
        public T Add(T obj)
        {

            while(Values.ContainsKey(NextIdentity))
            {
                NextIdentity++;
            }

            //Apply Id and validate.
            obj.Id = NextIdentity;
            obj.Validate();

            Values.Add(obj.Id, obj);

            return obj;

        }
        
        /// <summary>
        /// Method that tries to update an object in the dictionary, by passign an id, and an object containing the new values.
        /// The existing instance is overriden with the new given object.
        /// The updated object is then returned.
        /// </summary>
        /// <param name="id">Id to update.</param>
        /// <param name="obj">Object to update with.</param>
        /// <returns>Updated object.</returns>
        /// <exception cref="KeyNotFoundException">An exception is thrown, if the key does NOT exist.</exception>
        public T Update(int id, T obj)
        {
            if(Values.ContainsKey(id))
            {

                //Apply Id and validate.
                obj.Id = id;
                obj.Validate();

                //Overwrite existing instance of T with the given object.
                Values[id] = obj;

                return GetByIdentity(id);

            }

            throw new KeyNotFoundException($"Key ({id}) not found for {typeof(T).Name}");

        }

        /// <summary>
        /// Method that tries to delete an object in the dictionary, given by the passed id.
        /// The deletd object is then returned.
        /// </summary>
        /// <param name="id">Id to delete.</param>
        /// <returns>Deleted object.</returns>
        /// <exception cref="KeyNotFoundException">An exception is thrown, if the key does NOT exist.</exception>
        public T? Delete(int id)
        {

            if (Values.ContainsKey(id))
            {
                
                T deleted = Values[id];
                Values.Remove(id);

                return deleted;

            }

            throw new KeyNotFoundException($"Key ({id}) not found for {typeof(T).Name}");

        }
        #endregion

    }

}



