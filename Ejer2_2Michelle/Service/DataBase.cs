using Ejer2_2Michelle.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2_2Michelle.Service
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            //Creacion de las tablas de la base de datos

            dbase.CreateTableAsync<firma>(); //Creando la tabla Signature

        }

        #region OperacionesSignature
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateSignature(firma Signature)
        {
            if (Signature.Id != 0)
            {
                return dbase.UpdateAsync(Signature);
            }
            else
            {
                return dbase.InsertAsync(Signature);
            }
        }

        //Metodos CRUD - READ
        public Task<List<firma>> getListSignature()
        {
            return dbase.Table<firma>().ToListAsync();
        }

        public Task<firma> getSignature(int id)
        {
            return dbase.Table<firma>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteSignature(firma Signature)
        {
            return dbase.DeleteAsync(Signature);
        }

        #endregion OperacionesSignature

    }
}
