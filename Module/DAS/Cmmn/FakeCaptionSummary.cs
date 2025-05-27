using Infragistics.Win.UltraWinGrid;

namespace Cmmn
{
	internal class FakeCaptionSummary : ICustomSummaryCalculator
	{
		public void BeginCustomSummary(SummarySettings summarySettings, RowsCollection rows)
		{
		}

		public void AggregateCustomSummary(SummarySettings summarySettings, UltraGridRow row)
		{
		}

		public object EndCustomSummary(SummarySettings summarySettings, RowsCollection rows)
		{
			return "";
		}
	}
}
