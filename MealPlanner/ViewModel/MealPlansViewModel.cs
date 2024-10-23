using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using Domain.Models.Enums;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.ViewModel
{
    public partial class MealPlansViewModel :ObservableObject
    {
        private const int MEAL_PER_DAY = 3;
        private const int NUMBER_OF_DAYS_FOR_PLAN = 7;

        public MealPlansViewModel(IMealPlanService mealPlanService, IMealService mealService)
        {
            Plans = new ObservableCollection<MealPlan>();
            this.mealPlanService = mealPlanService;
            this.mealService = mealService;
        }

        [ObservableProperty]
        private ObservableCollection<MealPlan> plans = new ObservableCollection<MealPlan>();
        
        [ObservableProperty]
        private bool isRefreshing;

        private readonly IMealPlanService mealPlanService;
        private readonly IMealService mealService;


        [ICommand]
        public async Task RefreshPlansAsync()
        {
            IsRefreshing = true;
            try
            {

                var fetchedPlans = await mealPlanService.GetPlansForWeek();

                // Wyczyść istniejącą kolekcję
                Plans.Clear();

                // Dodaj nowe dane do istniejącej kolekcji, aby powiadomić UI
                foreach (var plan in fetchedPlans)
                {
                    Plans.Add(plan);
                }
                if (Plans.Count < MEAL_PER_DAY * NUMBER_OF_DAYS_FOR_PLAN)
                {
                    CreatePlansForWeek(Plans);  // Modyfikuj istniejącą kolekcję
                }
                //Plans = new ObservableCollection<MealPlan>(fetchedPlans);
                OnPropertyChanged(nameof(Plans));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        async void CreatePlansForWeek(ObservableCollection<MealPlan> plansForWeek)
        {
            DateTime dayOfWeekPlan = DateTime.Today.AddDays(6);
            for (int i = 6; i >= 0; i--)
            {
                if(plansForWeek.Where(p=> p.MealDate == dayOfWeekPlan).Count() == 3)
                {
                    dayOfWeekPlan = dayOfWeekPlan.AddDays(-1);
                    continue;
                }
                else
                {
                    int newPlanIdBre =0, newPlanIdLun = 0, newPlanIdDin = 0;
                    if (PlanForDayDoesNotExist(plansForWeek, dayOfWeekPlan, TypeOfMeal.Breakfast))
                        newPlanIdBre = await CreatePlanForDayPart(dayOfWeekPlan, TypeOfMeal.Breakfast);
                    if (PlanForDayDoesNotExist(plansForWeek, dayOfWeekPlan, TypeOfMeal.Lunch))
                        newPlanIdLun = await CreatePlanForDayPart(dayOfWeekPlan, TypeOfMeal.Lunch);
                    if (PlanForDayDoesNotExist(plansForWeek, dayOfWeekPlan, TypeOfMeal.Dinner))
                        newPlanIdDin = await CreatePlanForDayPart(dayOfWeekPlan, TypeOfMeal.Dinner);

                    if (newPlanIdBre > 0)
                    {
                        plansForWeek.Add(await mealPlanService.GetByIdAsync(newPlanIdBre));
                    }
                    if (newPlanIdLun > 0)
                    {
                        plansForWeek.Add(await mealPlanService.GetByIdAsync(newPlanIdLun));
                    }
                    if (newPlanIdDin > 0)
                    {
                        plansForWeek.Add(await mealPlanService.GetByIdAsync(newPlanIdDin));
                    }
                }
            }
        }

        private bool PlanForDayDoesNotExist(ObservableCollection<MealPlan> plansForWeek, DateTime dayOfWeekPlan, TypeOfMeal type)
        {
            return plansForWeek.Where(p => p.MealDate == dayOfWeekPlan && p.MealType == type).Count() == 0;
        }

        private async Task<int> CreatePlanForDayPart(DateTime dayOfWeekPlan, TypeOfMeal type)
        {
            int newPlanId = 0;
            Meal meal = await mealService.GetRandomMealByType(type);
            if (meal != null)
            {
                newPlanId = await mealPlanService.AddAsync(new MealPlan()
                {
                    Meal = meal,
                    MealDate = dayOfWeekPlan,
                    MealId = meal.Id,
                    MealType = type
                });
            }
            return newPlanId;
        }

        public IAsyncRelayCommand RefreshCommand { get; }
    }
}
