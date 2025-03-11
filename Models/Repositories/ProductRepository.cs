using ASP_5_Upload.Models.Entities;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;

namespace ASP_5_Upload.Models.Repositories
{
    public sealed class ProductRepository : IRepository<Tbl_Product>
    {
        private static ProductRepository _instance = null;
        private ProductRepository() { }
        public static ProductRepository Instance
        {
            get
            {
                _instance = _instance ?? new ProductRepository();
                return _instance;
            }
        }
        public bool Create(Tbl_Product item)
        {
            try
            {
                using (Db_Upload_Entities en = new Db_Upload_Entities())
                {
                    en.Tbl_Product.Add(item);
                    en.SaveChanges();
                    en.Dispose();
                    return true;
                }
            }
            catch (EntityException ex)
            {

            }
            return false;
        }

        public bool Delete(Tbl_Product item)
        {
            try
            {
                using (Db_Upload_Entities en = new Db_Upload_Entities())
                {
                    var q = en.Tbl_Product.SingleOrDefault(d => d.C_id == item.C_id);
                    en.Tbl_Product.Remove(q);
                    en.SaveChanges();
                    en.Dispose();
                    return true;
                }
            }
            catch (EntityException ex)
            {

            }
            return false;
        }

        public Tbl_Product Find(object id)
        {
            try
            {
                using (Db_Upload_Entities en = new Db_Upload_Entities())
                {
                    var q = en.Tbl_Product.SingleOrDefault(d => d.C_id == (int)id);
                    en.Dispose();
                    return q;
                }
            }
            catch (EntityException ex)
            {

            }
            return null;
        }

        public HashSet<Tbl_Product> FindAll(object keyword)
        {
            try
            {
                using (Db_Upload_Entities en = new Db_Upload_Entities())
                {
                    var q = en.Tbl_Product.Where(d => d.C_name.Equals(keyword.ToString())
                    || d.C_price.Equals((decimal)keyword)).ToHashSet();
                    en.Dispose();
                    return q;
                }
            }
            catch (EntityException ex)
            {

            }
            return null;
        }

        public HashSet<Tbl_Product> GetAll()
        {
            try
            {
                using (Db_Upload_Entities en = new Db_Upload_Entities())
                {
                    var q = en.Tbl_Product.ToHashSet();
                    en.Dispose();
                    return q;
                }
            }
            catch (EntityException ex)
            {

            }
            return null;
        }
        public HashSet<Tbl_Product> GetAll(int page, int pageSize)
        {
            try
            {
                using (Db_Upload_Entities en = new Db_Upload_Entities())
                {
                    /* var countItem = en.Tbl_Product.Count();
                     int indexSkip = 0;
                     int indexTake = 0;
                     if (page < 0)
                     {
                         indexSkip = 0;
                         indexTake = pageSize;
                     }
                     else
                     {
                         indexSkip = (page - 1) * pageSize;
                         indexTake = pageSize;
                         if (countItem-indexSkip <pageSize)
                         {
                             indexTake = countItem - indexSkip;
                         }
                     }
                     var q = en.Tbl_Product.
                         Skip(indexSkip).
                         Take(indexTake).ToHashSet();
                     en.Dispose();
                     return q;
                    */
                    var q = en.sp_product_paging(page, pageSize);
                    var res = q.Select(d => new Tbl_Product { C_id = d.C_id, C_name = d.C_name, C_price = d.C_price }).ToHashSet();
                    return res;
                }
            }
            catch (EntityException ex)
            {

            }
            return null;
        }

        public bool Update(Tbl_Product item)
        {
            try
            {
                using (Db_Upload_Entities en = new Db_Upload_Entities())
                {
                    var q = en.Tbl_Product.SingleOrDefault(d => d.C_id == item.C_id);
                    q.C_name = item.C_name;
                    q.C_price = item.C_price;
                    en.SaveChanges();
                    en.Dispose();
                    return true;
                }
            }
            catch (EntityException ex)
            {

            }
            return false;
        }
    }
}