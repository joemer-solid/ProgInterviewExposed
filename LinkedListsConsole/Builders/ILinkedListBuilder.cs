namespace LinkedListsConsole.Builders
{
    public interface ILinkedListBuilder<T, P>
    {
        T Build(P p);
    }
}
