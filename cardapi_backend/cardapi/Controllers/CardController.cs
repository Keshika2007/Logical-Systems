using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class CardsController : ControllerBase
{
    [HttpGet]
    public ActionResult<Dictionary<int, List<string>>> Get(int numberOfPeople)
    {
        if (numberOfPeople < 1 || numberOfPeople > 52)
        {
            return BadRequest("Input value does not exist, or value is invalid.");
        }

        // Initialize deck
        var suits = new[] { 'S', 'H', 'D', 'C' };
        var ranks = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        var deck = new List<string>();
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                deck.Add($"{suit}-{rank}");
            }
        }

        // Shuffle deck
        var random = new Random();
        deck = deck.OrderBy(x => random.Next()).ToList();

        // Distribute cards
        var cardDistribution = new Dictionary<int, List<string>>();
        for (int i = 0; i < numberOfPeople; i++)
        {
            cardDistribution[i] = new List<string>();
        }

        for (int i = 0; i < deck.Count; i++)
        {
            cardDistribution[i % numberOfPeople].Add(deck[i]);
        }

        return Ok(cardDistribution.ToDictionary(
            kvp => kvp.Key + 1,
            kvp => kvp.Value
        ));
    }
}