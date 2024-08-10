namespace Halle.Application.Dtos
{
    public record ConfigRebalancingDto
    {
        public decimal ContributionValue { get; set; }
        public int QtdClassesContributed { get; set; }
        public int QtdFinalAssetsContributed { get; set; }
    }
}
