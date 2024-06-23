namespace Task_SeniordotNETDeveloper.Models
{
    public class OrderModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        /*
            Také bych přidal třídu User a propojil ji s Order. A provést automatické generování účtu pro nového uživatele
            To znamená, že pokud uživatel není oprávněn,
            automaticky vytvoříme účet z údajů,
            které zadal pro doručení objednávky,
            a na jeho e-mailovou adresu mu zašleme nabídku k nastavení hesla k tomuto účtu.
         */
    }
}
