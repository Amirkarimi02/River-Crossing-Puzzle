# River Crossing Puzzle Solver

This is a Windows Forms application that solves the River Crossing puzzle. The puzzle involves a group of individuals crossing a river using a boat, while obeying certain rules and constraints.

## Getting Started

To run the application, you need to have Visual Studio and .NET Framework installed. Simply open the solution file in Visual Studio, build the project, and run it.

## Puzzle Description

The puzzle consists of nine characters: Police, Thief, Father, Mother, Son1, Son2, Daughter1, Daughter2, and the Boat. The characters are initially positioned on the left bank of the river. The goal is to move all characters to the right bank, following these rules:

1. Only the Police, Father, or Mother can drive the boat.
2. The Thief and the Police must always be together, or the Thief must be alone.
3. If at least one Son is with the Mother, the Father must also be present.
4. If at least one Daughter is with the Father, the Mother must also be present.

## Application Features

The application provides the following features:

1. GUI Interface: The puzzle is represented visually using PictureBox controls to display the characters and the boat on both sides of the river.
2. Step-by-Step Solution: The application generates a solution to the puzzle and displays each step in the GUI. You can navigate through the steps using the navigation buttons.
3. Validation: Before generating the solution, the application validates the initial state to ensure it satisfies the puzzle rules.
4. Professional Design: The GUI is designed with user-friendly controls and a clean layout to enhance the user experience.

## How to Use

1. Launch the application.
2. The characters are displayed on the left bank of the river.
3. Click the "Generate Solution" button to find a solution to the puzzle.
4. The solution steps will be displayed one by one in the GUI.
5. Use the navigation buttons to move forward or backward through the solution steps.
6. Enjoy watching the characters move across the river until they all reach the right bank.

## Development and Contributions

The application was developed using C# and the Windows Forms framework. Contributions to the project are welcome. Feel free to submit bug reports, feature requests, or pull requests on the GitHub repository.

## Credits

This application was created as part of an AI project and developed by [Your Name]. The project uses images from [Image Source].

## License

This project is licensed under the [MIT License](LICENSE.md). Feel free to use, modify, and distribute the code for personal or commercial purposes.

## Contact

For any inquiries or questions, please contact [karimika13.ka@gmail.com].

Thank you for using the River Crossing Puzzle Solver!
