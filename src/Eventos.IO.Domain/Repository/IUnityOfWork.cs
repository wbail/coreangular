using Eventos.IO.Domain.Core.Commands;
using System;

namespace Eventos.IO.Domain.Repository
{
    public interface IUnityOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
