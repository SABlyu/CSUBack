namespace WebApplication1
{
    public class AsyncFoo
    {
        public async Task DoFoo()
        {
            await Foo1();
            Foo2();
        }

        public async Task<object> Foo1()
        {
            return await Task.FromResult<object>(null);
        }

        public async void Foo2()
        {
            await Task.FromResult<object>(null);
        }
    }
}
