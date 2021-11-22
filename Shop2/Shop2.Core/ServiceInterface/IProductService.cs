﻿using Shop2.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Shop2.Core.ServiceInterface
{
    public interface IProductService
    {
        Task<Product> Delete(Guid id);
    }
}