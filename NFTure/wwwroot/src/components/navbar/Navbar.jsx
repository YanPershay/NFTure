import React, { useState } from "react";
import "./Navbar.css";
import { MenuData } from "./MenuData.js";

const Navbar = () => {
  const [isMenuClicked, setIsMenuClicked] = useState(false);

  return (
    <nav className="navbarItems">
      <h1 className="logo">
        NFTure <i className="fa-solid fa-dice-d20"></i>
      </h1>
      <div className="menu-icons" onClick={() => setIsMenuClicked(!isMenuClicked)}>
        <i className={isMenuClicked ? "fas fa-times" : "fas fa-bars"}></i>
      </div>
      <ul className={isMenuClicked ? "nav-menu active" : "nav-menu"}>
        {MenuData.map((item, index) => {
          return (
            //TODO: move to another component
            <li key={index}>
              <a href={item.url} className={item.className}>
                <i className={item.icon}></i>
                {item.title}
              </a>
            </li>
          );
        })}
      </ul>
    </nav>
  );
};

export default Navbar;
