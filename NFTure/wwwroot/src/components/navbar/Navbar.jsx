import React, { useState } from "react";
import "./Navbar.css";
import { BrowserRouter } from "react-router-dom";
import { MenuData } from "./MenuData.js";
import MenuItem from "./menu-item/MenuItem";

const Navbar = () => {
  const [isMenuClicked, setIsMenuClicked] = useState(false);

  return (
    <nav className="navbarItems">
      <h1 className="logo">
        NFTure <i className="fa-solid fa-dice-d20"></i>
      </h1>
      <div
        className="menu-icons"
        onClick={() => setIsMenuClicked(!isMenuClicked)}
      >
        <i className={isMenuClicked ? "fas fa-times" : "fas fa-bars"}></i>
      </div>
      <ul className={isMenuClicked ? "nav-menu active" : "nav-menu"}>
        {MenuData.map((item, index) => {
          return (
            <li key={index}>
              <MenuItem item={item} />
            </li>
          );
        })}
      </ul>
    </nav>
  );
};

export default Navbar;
