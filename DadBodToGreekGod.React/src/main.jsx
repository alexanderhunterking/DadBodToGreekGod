import React from 'react';
import ReactDOM from 'react-dom';
import App from './components/App';
import './css/index.css';

const Main = () => {
  return (
    <React.StrictMode>
      <App />
    </React.StrictMode>
  );
};

ReactDOM.createRoot(document.getElementById('rootDiv')).render(<Main />);
