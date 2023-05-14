namespace WebshopAPI.Models.DTOs;

public class TransactionViewDto
{
    #region Properties and Indexers
    public int Amount { get; set; }
    public DateTime DateTime { get; set; }
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    #endregion
}
