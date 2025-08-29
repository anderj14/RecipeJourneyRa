## 🍳 RecipeJourneyRa

**RecipeJourneyRa** is a web application focused on managing culinary recipes, designed to simplify the creation, storage, and organization of recipes in a digital environment. This app allows users to store their favorite recipes, categorize them, and access them efficiently.

### 🛠️ Technologies

* **Backend**: ASP.NET Core MVC
* **Frontend**: Razor Pages
* **Database**: SQL Server
* **Containers**: Docker
* **Authentication**: Identity Framework

### 📂 Project Structure

The project follows a standard MVC architecture, with the following main folders:

* **Controllers**: Controllers that handle business logic and interactions with the views.
* **Data**: Contains the database context and initialization classes.
* **Models**: Models representing database entities, such as `Receta` (Recipe) and `Ingrediente` (Ingredient).
* **Views**: Views that render the user interface.
* **wwwroot**: Static files such as CSS, JavaScript, and images.

### 🚀 Key Features

* **Recipe Management**: Users can create, edit, and delete recipes, including details like ingredients, instructions, and preparation time.
* **Dockerized**: Uses Docker to containerize the application, making deployment and scalability easier.

### 🧪 Installation and Running

1. Clone the repository:

   ```bash
   git clone https://github.com/anderj14/RecipeJourneyRa.git
   ```

2. Navigate to the project directory:

   ```bash
   cd RecipeJourneyRa
   ```

3. Build and run the Docker container:

   ```bash
   docker-compose up --build
   ```

4. Access the application in your browser at `http://localhost:5083`.
