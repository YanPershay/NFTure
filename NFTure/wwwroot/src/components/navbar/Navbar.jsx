import React from "react";
import "./Navbar.css";

const Navbar = () => {
  return (
    <nav className="navbarItems">
      <h1>
        NFTure <i className="fab fa-react"></i>
      </h1>
      <ul>
        <li>
          <a>
            <i className="fa-solid fa-house-user"></i> Home
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default Navbar;
