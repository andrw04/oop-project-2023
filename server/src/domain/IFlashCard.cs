namespace Domain
{
    public interface IFlashCard
    {
        Page Show();
        long ModuleId{get;}
        long Id{get;}

    }
}