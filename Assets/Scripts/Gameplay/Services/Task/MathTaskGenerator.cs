using System;
using Gameplay.Enums;
using Views.PathPointBehaviours;
using Random = UnityEngine.Random;

namespace Gameplay.Services.Path
{
    public class MathTaskGenerator
    {
        private readonly LevelContainer _levelContainer;

        public MathTaskGenerator(LevelContainer levelContainer)
        {
            _levelContainer = levelContainer;
        }

        public void GenerateTasks()
        {
            var pathModel = _levelContainer.PathModel;
            var pathView = _levelContainer.PathView;

            int pathPointIndex = 0;

            while (pathPointIndex <= pathModel.TotalProgress)
            {
                pathPointIndex += Random.Range(3, 6);

                var mathTaskPathPoint = GenerateMathTaskPoint();
                var pathPointView = pathView.PathPoints[pathPointIndex];

                pathModel.PathPointBehaviours.Add(pathPointView, mathTaskPathPoint);
            }
        }

        private MathTaskPathPoint GenerateMathTaskPoint()
        {
            var operation = GetRandomOperation();

            int number1;
            int number2;
            int answer = 0;
            string taskText = "task_default";

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
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(0, 10);
                    number1 = number1 * number2;

                    answer = number1 / number2;

                    taskText = $"{number1} / {number2} = ?";
                    break;
            }

            var mathTaskPathPoint = new MathTaskPathPoint(_levelContainer.MathTaskView, taskText, answer, 2);

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