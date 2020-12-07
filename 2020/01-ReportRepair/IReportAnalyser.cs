namespace ExpenseReport
{
    public interface IReportAnalyser
    {
        (int, int) FindTwoValuesTotalling(int sumOfValues);
        (int, int, int) FindThreeValuesTotalling(int sumOfValues);
    }
}