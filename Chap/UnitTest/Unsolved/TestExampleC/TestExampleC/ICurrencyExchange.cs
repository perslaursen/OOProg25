
/// <summary>
/// Definitions:
/// A vaild currency identifier consists of exactly three letters in upper-case.
/// A valid currency cross consists of two non-identical valid currency identifiers.
/// </summary>
public interface ICurrencyExchange
{
	/// <summary>
	/// Sets the exchange rate for the given currency cross
	/// 1) "from" must be a valid currency identifier
	/// 2) "to" must be a valid currency identifier
	/// 3) "from" must not be equal to "to"
	/// 4) "rate" must be a positive number
	/// 5) All violations cause throw of ArgumentException
	/// 6) Any existing occurrence of the currency cross will be overwritten.
	/// </summary>
	void SetExchangeRate(string from, string to, double rate);

	/// <summary>
	/// Gets the exchange rate for the given currency cross
	/// 1) "from" must be a valid currency identifier
	/// 2) "to" must be a valid currency identifier
	/// 3) "from" must not be equal to "to"
	/// 4) "from-to" Currency cross must be registered
	/// 5) All violations cause throw of ArgumentException
	/// 6) Returned rate must be identical to the latest registered rate.
	/// </summary>
	double GetExchangeRate(string from, string to);

	/// <summary>
	/// Get the amount of currency in the "to"-currency, given
	/// the "from"-currency and the amount in "from"-currency
	/// 1) "from" must be a valid currency identifier
	/// 2) "to" must be a valid currency identifier
	/// 3) "from" must not be equal to "to"
	/// 4) "amount" must be a positive number
	/// 5) "from-to" Currency cross must be registered
	/// 6) All violations cause throw of ArgumentException
	/// 7) Returned amount must be correct according to exchange rate
	/// </summary>
	double GetAmount(string from, double fromAmount, string to);

	/// <summary>
	/// A vaild currency identifier consists of exactly three letters in upper-case.
	/// </summary>
	bool ValidateCurrencyIdentifier(string currencyId);
}
