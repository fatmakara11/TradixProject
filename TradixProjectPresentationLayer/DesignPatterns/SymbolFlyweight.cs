namespace TradixProjectPresentationLayer.DesignPatterns
{
    public class SymbolFlyweight
    {
        private static readonly Dictionary<string, SymbolFlyweight> _symbols = new();

        public string Symbol { get; private set; }

        private SymbolFlyweight(string symbol)
        {
            Symbol = symbol;
        }

        public static SymbolFlyweight GetSymbol(string symbol)
        {
            if (!_symbols.ContainsKey(symbol))
            {
                _symbols[symbol] = new SymbolFlyweight(symbol);
            }

            return _symbols[symbol];
        }
    }
}
