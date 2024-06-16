namespace Halle.Domain.Entities.YahooFinance
{
    public record StockQuote
    {
        public double Ask { get; init; }
        public long AskSize { get; init; }
        public long AverageDailyVolume10Day { get; init; }
        public long AverageDailyVolume3Month { get; init; }
        public double Bid { get; init; }
        public long BidSize { get; init; }
        public double BookValue { get; init; }
        public string Currency { get; init; } = null!;
        public long DividendDate { get; init; }
        public long EarningsTimestamp { get; init; }
        public long EarningsTimestampEnd { get; init; }
        public long EarningsTimestampStart { get; init; }
        public double EpsForward { get; init; }
        public double EpsTrailingTwelveMonths { get; init; }
        public string Exchange { get; init; } = null!;
        public long ExchangeDataDelayedBy { get; init; }
        public string ExchangeTimezoneName { get; init; } = null!;
        public string ExchangeTimezoneShortName { get; init; } = null!;
        public double FiftyDayAverage { get; init; }
        public double FiftyDayAverageChange { get; init; }
        public double FiftyDayAverageChangePercent { get; init; }
        public double FiftyTwoWeekHigh { get; init; }
        public double FiftyTwoWeekHighChange { get; init; }
        public double FiftyTwoWeekHighChangePercent { get; init; }
        public double FiftyTwoWeekLow { get; init; }
        public double FiftyTwoWeekLowChange { get; init; }
        public double FiftyTwoWeekLowChangePercent { get; init; }
        public string FinancialCurrency { get; init; } = null!;
        public double ForwardPE { get; init; }
        public string FullExchangeName { get; init; } = null!;
        public long GmtOffSetMilliseconds { get; init; }
        public string Language { get; init; } = null!;
        public string LongName { get; init; } = null!;
        public string Market { get; init; } = null!;
        public long MarketCap { get; init; }
        public string MarketState { get; init; } = null!;
        public string MessageBoardId { get; init; } = null!;
        public long PriceHint { get; init; }
        public double PriceToBook { get; init; }
        public string QuoteSourceName { get; init; } = null!;

        public string QuoteType { get; init; } = null!;

        public double RegularMarketChange { get; init; }

        public double RegularMarketChangePercent { get; init; }

        public double RegularMarketDayHigh { get; init; }

        public double RegularMarketDayLow { get; init; }
  
        public double RegularMarketOpen { get; init; }

        public double RegularMarketPreviousClose { get; init; }

        public long RegularMarketTime { get; init; }

        public double RegularMarketPrice { get; init; }

        public long RegularMarketVolume { get; init; }

        public double PostMarketChange { get; init; }

        public double PostMarketChangePercent { get; init; }

        public double PostMarketPrice { get; init; }

        public long PostMarketTime { get; init; }

        public long SharesOutstanding { get; init; }

        public string ShortName { get; init; } = null!;

        public long SourceInterval { get; init; }

        public string Symbol { get; init; } = null!;
        public bool Tradeable { get; init; }

        public double TrailingAnnualDividendRate { get; init; }

        public double TrailingAnnualDividendYield { get; init; }

        public double TrailingPE { get; init; }

        public double TwoHundredDayAverage { get; init; }

        public double TwoHundredDayAverageChange { get; init; }

        public double TwoHundredDayAverageChangePercent { get; init; }
    }
}
