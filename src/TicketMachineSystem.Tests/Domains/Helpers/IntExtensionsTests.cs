using TicketMachineSystem.Domains.Helpers;

namespace TicketMachineSystem.Tests.Domains.Helpers
{
    public class IntExtensionsTests
    {
        [Fact]
        public void ToStringYen()
        {
            var price = 1234;
            var displayPrice = price.ToStringYen();

            Assert.Equal("¥1,234", displayPrice);
        }
    }
}