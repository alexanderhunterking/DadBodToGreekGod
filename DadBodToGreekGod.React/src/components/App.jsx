import React from 'react';
import '../../node_modules/bootstrap/dist/css/bootstrap.min.css';

const App = () => {
  return (
        <div className="position-absolute top-50 start-50 translate-middle">
          <div className="container text-center text-light">
            <div className="row justify-content-center">
              <div className="col-8">
                <h2>Go From Dad Bod to Greek God!</h2>
                <br />
                <p className="text-secondary">
                  "Dad Bod to Greek God" is your go-to app for transforming your
                  physique and improving your health through easy meal planning.
                  This user-friendly app provides personalized meal suggestions,
                  simple recipes, and nutritional guidance, making it easy for
                  anyone to go from a relaxed dad bod to a sculpted Greek god.
                </p>
              </div>
            </div>
            <br />
            <div className="row justify-content-center">
              <div className="col-xl-2 col-lg-3 col-md-4">
                <a href="./pages/signUp.html" className="btn btn-primary">
                  Sign Up
                </a>
              </div>
              <div className="col-xl-2 col-lg-3 col-md-4">
                <a href="./pages/login.html" className="btn btn-secondary">
                  Login
                </a>
              </div>
            </div>
          </div>
        </div>
  );
};

export default App;