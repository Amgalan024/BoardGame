using System;
using System.Collections.Generic;
using Gameplay.Enums;
using Models;
using Views;
using Views.PathPointBehaviours;
using Random = UnityEngine.Random;

namespace Gameplay.Services.Path
{
    public class MathTaskMapGenerator : IBehaviorMapGenerator
    {
        private readonly LevelContainer _levelContainer;
        private readonly LevelModel _levelModel;

        public MathTaskMapGenerator(LevelContainer levelContainer, LevelModel levelModel)
        {
            _levelContainer = levelContainer;
            _levelModel = levelModel;
        }

        List<PathPointView> IBehaviorMapGenerator.GenerateBehavioursMap()
        {
            var pathModel = _levelContainer.PathModel;
            var pathView = _levelContainer.PathView;

            int pathPointIndex = 0;

            var minStep = 3;
            var maxStep = 6;

            var behaviourMap = new List<PathPointView>();

            while (pathPointIndex <= pathModel.TotalProgress - 1)
            {
                pathPointIndex += Random.Range(minStep, maxStep);

                if (pathPointIndex >= pathModel.TotalProgress)
                {
                    return behaviourMap;
                }

                var pathPointView = pathView.PathPoints[pathPointIndex];

                pathPointView.SetTaskSign();

                behaviourMap.Add(pathPointView);
            }

            return behaviourMap;
        }

        IPathPointBehaviour IBehaviorMapGenerator.GeneratePathPointBehaviour()
        {
            var operation = GetRandomOperation();

            int number1;
            int number2;
            int answer = 0;
            string taskText = "task_default";
            int reward = Random.Range(1, 4);

            switch (operation)
            {
                case MathOperationTypes.Addition:
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(0, 10);

                    answer = number1 + number2;

                    taskText = $"{number1} + {number2} = ?";
                    break;
                case MathOperationTypes.Subtraction:
                    number1 = Random.Range(1, 20);
                    number2 = Random.Range(0, number1);

                    answer = number1 - number2;

                    taskText = $"{number1} - {number2} = ?";
                    break;
                case MathOperationTypes.Multiplication:
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(0, 10);

                    answer = number1 * number2;

                    taskText = $"{number1} * {number2} = ?";
                    break;
                case MathOperationTypes.Division:
                    number1 = Random.Range(1, 10);
                    number2 = Random.Range(1, 10);
                    number1 = number1 * number2;

                    answer = number1 / number2;

                    taskText = $"{number1} / {number2} = ?";
                    break;
            }

            var mathTaskPathPoint =
                new MathTaskPathPoint(_levelContainer.MathTaskView, _levelModel, taskText, answer, reward);

            return mathTaskPathPoint;
        }

        private MathOperationTypes GetRandomOperation()
        {
            var operations = Enum.GetValues(typeof(MathOperationTypes));

            var random = Random.Range(0, operations.Length);

            return (MathOperationTypes) operations.GetValue(random);
        }
    }
}