const serverEndpoint = 'server-endpoint'
const server = 'http://localhost:5099/'

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
function submitCreateRecipeForm() {
    event.preventDefault(); 
    
    const form = document.getElementById('recipeForm');
    const formData = new FormData(form);

    fetch('/Recipes/Create', {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (response.ok) {
                // Redirect to the recipe details page on successful creation
                window.location.href = '/Recipes/Detail/' + response.id;
            } else {
                // Handle errors or display error messages
                console.error('Error creating recipe:', response.statusText);
            }
        })
        .catch(error => {
            console.error('Error creating recipe:', error);
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
