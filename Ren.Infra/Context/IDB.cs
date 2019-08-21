using System;
using System.Data;

namespace Ren.Infra.Context
{
    public interface IDB : IDisposable
    {
        IDbConnection Connection();
    }
}