namespace FitskedApp.Helpers
{
    public interface IFilteredExercisesManager
    {
        public void RemoveItemFromList<T>(T item, List<T> list);
        public void AddItemToList<T>(T item, List<T> list);
        public void RemoveItemsFromList<T>(IEnumerable<T> items, List<T> list);
        public void AddItemsToList<T>(IEnumerable<T> items, List<T> list);
    }
}
