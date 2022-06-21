using System.Text;
using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Helpers;
using TicketMachineSystem.Domains.Repositories;

namespace TicketMachineSystem.Infrastructures.Csv
{
    /// <summary>
    /// カテゴリCSVリポジトリ
    /// </summary>
    public class CategoryCsv : ICategoryRepository
    {
        /// <inheritdoc/>
        public IEnumerable<Category> GetAll()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return CsvParser.Read<Category>($@"{nameof(Category).ToLower()}.csv", Encoding.GetEncoding("Shift_JIS"), ",");
        }
    }
}