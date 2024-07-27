var amount = 0.5075m;

var club = new ClubDiscountProcessor();
club.Calculate(amount * 100);

IDiscountProcessor adapter = new DiscountAdapter(new ClubDiscountProcessor());
adapter.Calculate(amount);

public interface IDiscountProcessor
{
    void Calculate(decimal discount);
}
public class ClubDiscountProcessor
{
    public void Calculate(decimal discountInPercent)
    {
        Console.WriteLine($"Processing discount of {discountInPercent}% through Club.");
    }
}

public class DiscountAdapter : IDiscountProcessor
{
    private readonly ClubDiscountProcessor _discountGateway;

    public DiscountAdapter(ClubDiscountProcessor discountGateway)
    {
        _discountGateway = discountGateway;
    }

    public void Calculate(decimal discount)
    {
        decimal amountInCents = discount * 100;
        _discountGateway.Calculate(amountInCents);
    }
}