using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class BaseController : IDisposable
{
    private List<BaseController> _baseControllers;
    private List<GameObject> _gameObjects;
    private bool _isDisposed;

    public void Dispose()
    {
        if (!_isDisposed)
        {
            _isDisposed = true;
            if (null != _baseControllers)
            {
                foreach (BaseController baseController in _baseControllers)
                {
                    baseController?.Dispose();
                }
                _baseControllers.Clear();
            }

            if (null != _gameObjects)
            {
                foreach (GameObject cachedGameObject in _gameObjects)
                {
                    Object.Destroy(cachedGameObject);
                }
                _gameObjects.Clear();
            }

        }

        OnDispose();
    }
    protected void AddController(BaseController baseController)
    {
        if (null == _baseControllers)
            _baseControllers = new List<BaseController>();

        _baseControllers.Add(baseController);
    }

    protected void AddGameObject(GameObject gameObject)
    {
        if (null == _gameObjects)
            _gameObjects = new List<GameObject>();

        _gameObjects.Add(gameObject);
    }

    protected abstract void OnDispose();
}
