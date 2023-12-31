﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDataAccessLayer.Abstracts
{
    public interface IGenericDal<T> where T : class
    {
        Task Insert(T t);
        Task Delete(T t);
        Task Update(T t);
        Task<List<T>> GetList();

        Task<T> GetById(int id);
    }
}
