
public class Helpers
{
	/// <summary>
	/// Returnerer en List af alle eksisterende DamageType-værdier.
	/// </summary>
	public static List<DamageType> DamageTypeList
	{
		get { return Enum.GetValues<DamageType>().ToList(); }
	}

	/// <summary>
	/// Konverterer en Dictionary til en enkelt string, hvor værdierne står komma-separeret.
	/// </summary>
	public static string DictionaryToString<K,V>(Dictionary<K,V> dict) where K : notnull
	{
		return string.Join(", ", dict.Select(kvp => $"{kvp.Key} = {kvp.Value}"));
	}
}
