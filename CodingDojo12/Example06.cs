namespace ConsoleApplication1
{
    public class ConcretePresenter : IPresenter<ConcreteModel, ConcreteView> 
    {
    }

    public class ConcreteView : IView
    {
    }

    public class ConcreteModel : IModel
    {
    }

    //Here we define TModel and TView because T1 and T2 would be confusing.
    public interface IPresenter<TModel, TView> where TModel : IModel where TView : IView {}
    
    public interface IModel {}
    public interface IView {}
}