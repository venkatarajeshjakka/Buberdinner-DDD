# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id": "000-0000-000",
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "averageRating": 4.5,
  "sections": [
    {
      "id": "000-000-000",
      "name": "Appetizers",
      "descriptions": "Starters",
      "items": [
        {
          "id": "000-000-000",
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 5.99
        }
      ]
    }
  ],
  "createdDateTime": "2023-01-01T00:0000Z",
  "updatedDateTime": "2023-01-01T00:0000Z",
  "hostId": "000-000-000",
  "dinnerIds": ["000-000-000"],
  "menuReviewIds": ["000-000-000"]
}
```
