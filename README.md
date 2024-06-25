# Greggs.Product Web API Project

## Solution Overview

I restructured the Greggs.Product web API project using Clean Architecture principles to ensure easy scalability and maintainability. Additionally, I implemented the Repository and Builder design patterns. As part of this restructuring, I moved the Data Access layer to the Infrastructure layer.

## User Story 1

To address this user story, I expanded the entities to align closely with what is available on the Gregg's website rather than the initial list of data provided. Retrieving the latest products can be based on the date or ID, so I enhanced the product table accordingly. The following entities were included to support this functionality:

- **Category**: Captures all product categories available on the menu, such as breakfast items.
- **Nutritional Information**: Stores detailed nutritional content for products, including measurements and values.
- **Nutrients**: A lookup table that stores various food nutrients and their unit values.

## User Story 2

This user story targets entrepreneurs looking to expand to Europe. Considering potential future expansions to other locations, I added a location table to capture location-specific data, including exchange rates. The default location is set to Europe.

## Technical Details

- **.NET Upgrade**: Please upgrade to .NET 8 to run this application.
- **Data Seeding**: Migrations have been applied in `Startup.cs` to seed data for testing purposes.

### Design Patterns

- **Repository Pattern**: Ensures a clear separation of concerns and promotes a more maintainable codebase.
- **Builder Pattern**: Facilitates complex object creation, enhancing code readability and maintainability.

### Clean Architecture

The project is structured according to Clean Architecture principles, which segregate the code into different layers: 

- **Core Layer**: Contains the domain entities.
- **Application Layer**: Houses the interfaces and application services.
- **Infrastructure Layer**: Includes data access  implementations.
- **Presentation Layer**: Manages the API controllers and user interactions.
