﻿using DienmayShop.ViewModel;

namespace DienmayShop.Application.PhungTest
{
    public interface IPhungTestService
    {
        Task<List<PhungTestVM>> GetAll ();
    }
}
