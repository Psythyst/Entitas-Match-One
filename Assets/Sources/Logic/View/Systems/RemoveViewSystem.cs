﻿using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public sealed class RemoveViewSystem : ReactiveSystem<GameEntity> {

    public RemoveViewSystem(GameContext Game) : base(Game) {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(
            GameMatcher.Asset.Removed(),
            GameMatcher.Destroyed.Added()
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities) {
            destroyView(e.view);
            e.RemoveView();
        }
    }

    void destroyView(ViewComponent viewComponent) {
        var gameObject = viewComponent.gameObject;
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.material.DOColor(color, 0.2f);
        gameObject.transform
                  .DOScale(Vector3.one * 1.5f, 0.2f)
                  .OnComplete(() => {
                      gameObject.Unlink();
                      Object.Destroy(gameObject);
                  });
    }
}
