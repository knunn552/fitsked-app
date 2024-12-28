

namespace FitskedApp.Helpers
{
    public class FilteredExercisesManager : IFilteredExercisesManager
    {
        public void AddItemsToList<T>(IEnumerable<T> items, List<T> list)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }

        public void AddItemToList<T>(T item, List<T> list)
        {
            list.Add(item);
        }
        public void RemoveItemFromList<T>(T item, List<T> list)
        {
            list.Remove(item);
        }

        public void RemoveItemsFromList<T>(IEnumerable<T> items, List<T> list)
        {
            foreach (var item in items)
            {
                list.Remove(item);
            }
        }
    }
}
