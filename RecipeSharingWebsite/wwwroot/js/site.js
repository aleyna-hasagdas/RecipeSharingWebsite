const serverEndpoint = 'server-endpoint'


// Login Form
function submitLoginForm(event) {
    event.preventDefault();

    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value;

    var formData = {
        email: email,
        password: password
    };


    // Send the form data to the server
    fetch(serverEndpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    })
        .then(function(response) {
            if (response.ok) {
                // Login successful
                alert('Login successful!');
                document.getElementById('loginForm').reset(); // Clear form fields
            } else {
                alert('Invalid email or password. Please try again.');
            }
        })
        .catch(function(error) {
            console.error('Error:', error);
            alert('Error logging in. Please try again.');
        });
}



// Sign In Form
function submitSignInForm(event) {
    event.preventDefault();

    var firstName = document.getElementById('firstName').value;
    var lastName = document.getElementById('lastName').value;
    var username = document.getElementById('username').value;
    var description = document.getElementById('description').value;
    var userImage = document.getElementById('userImage').value;
    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value;

    var formData = {
        firstName: firstName,
        lastName: lastName,
        username: username,
        description: description,
        userImage: userImage,
        email: email,
        password: password
    };


    // Send the form data to the server
    fetch(serverEndpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    })
        .then(function(response) {
            if (response.ok) {
                // Form submitted successfully
                alert('Sign-in successful!');
                document.getElementById('signinForm').reset(); // Clear form fields
            } else {
                alert('Error signing in. Please try again.');
            }
        })
        .catch(function(error) {
            console.error('Error:', error);
            alert('Error signing in. Please try again.');
        });
}



// Create Recipe Form
function submitCreateRecipeForm(event) {
    event.preventDefault();

    var recipeName = document.getElementById('recipeName').value;
    var description = document.getElementById('description').value;
    var category = document.getElementById('category').value;
    var recipeImage = document.getElementById('recipeImage').value;
    var instructions = document.getElementById('instructions').value;
    var ingredients = [];

    var ingredientInputs = document.getElementsByName('ingredient[]');
    var quantityInputs = document.getElementsByName('quantity[]');


    for (var i = 0; i < ingredientInputs.length; i++) {
        var ingredient = ingredientInputs[i].value;
        var quantity = quantityInputs[i].value;
        ingredients.push({ ingredient: ingredient, quantity: quantity });
    }

    var formData = {
        recipeName: recipeName,
        description: description,
        category: category,
        recipeImage: recipeImage,
        instructions: instructions,
        ingredients: ingredients
    };

    // Send the form data to the server
    fetch(serverEndpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    })
        .then(function(response) {
            if (response.ok) {
                // Recipe created successfully
                alert('Recipe created successfully!');
                document.getElementById('recipeForm').reset();
            } else {
                alert('Error creating recipe. Please try again.');
            }
        })
        .catch(function(error) {
            console.error('Error:', error);
            alert('Error creating recipe. Please try again.');
        });
}


// Function to check if the user is logged in
function checkLoginStatus() {
    // Send a request to the server to check login status
    fetch('/check-login', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
        credentials: 'include' // Include cookies or authentication headers for the server to verify
    })
        .then(function(response) {
            if (response.ok) {
                console.log('User is logged in');
                return true
            } else {
                console.log('User is not logged in');
            }
        })
        .catch(function(error) {
            console.error('Error:', error);
        });
}
