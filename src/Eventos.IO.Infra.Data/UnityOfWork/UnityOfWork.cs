using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Repository;
using Eventos.IO.Infra.Data.Context;

namespace Eventos.IO.Infra.Data.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly EventsContext _context;

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
