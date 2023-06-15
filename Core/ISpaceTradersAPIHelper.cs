﻿using SpaceTradersApp.MVVM.Model;
using System.Threading.Tasks;

namespace SpaceTradersApp.Core
{
    public interface ISpaceTradersAPIHelper
    {
        /// <summary>
        /// Sets the token for the API Calls
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets the Account Data
        /// </summary>
        /// <returns></returns>
        Task<AccountModel?> getAccountDataAsync();

        /// <summary>
        /// Gets The List of Available Ships
        /// </summary>
        /// <returns></returns>
        Task<FleetModelResponse?> getShipsDataAsync();
    }
}