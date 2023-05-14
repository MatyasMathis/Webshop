namespace WebshopAPI.Models;

public class Transaction : IIdentifiableByGuid
{
    #region Properties and Indexers
    public int Amount { get; set; }
    public DateTime DateTime { get; set; }
    public Guid Id { get; set; }

    /// <summary>
    ///     <see cref="Product" /> price might change, so store a copy
    /// </summary>
    public decimal Price { get; set; }

    public virtual Product Product { get; set; }
    public Guid ProductId { get; set; }
    public virtual User User { get; set; }
    public Guid UserId { get; set; }
    #endregion
}
