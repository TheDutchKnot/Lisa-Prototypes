namespace Tdk.Systems.ObjectPooling {
    public interface IPoolObjectSettings {
        public IPoolObject Create();

        public void OnGet(IPoolObject obj);
        public void OnRelease(IPoolObject obj);
        public void OnDestroyPoolObject(IPoolObject obj);
    }
}