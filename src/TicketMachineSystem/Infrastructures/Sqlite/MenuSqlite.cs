using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Repositories;

namespace TicketMachineSystem.Infrastructures.Sqlite
{
    /// <summary>
    /// メニューSqliteリポジトリ
    /// </summary>
    public class MenuSqlite : IMenuRepository
    {
        /// <inheritdoc/>
        public IEnumerable<Menu> GetAllMenu()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerable<Menu> GetMainMenu()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerable<Menu> GetOption()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerable<Menu> GetSide1()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerable<Menu> GetSide2()
        {
            throw new NotImplementedException();
        }
    }
}