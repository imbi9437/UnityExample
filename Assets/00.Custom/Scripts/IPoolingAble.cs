using UnityEngine;

public interface IPoolingAble
{
    public IPoolingAble Create();

    public void Get(IPoolingAble data);
    
    public void Release(IPoolingAble data);

    public void Destroy(IPoolingAble data);
}
