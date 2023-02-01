import "./Card.css";
import picture from "./card_image.jpg";

const Card = () => {
  return (
    <div className="card">
      <div className="picture">
        <img src={picture} alt="NFT"></img>
      </div>
      <div className="characteristics">
        <p className="pictureName">Name of the picture</p>
        <div className="bids">
          <div className="titles">
            <p className="title">Current Bid</p>
            <p className="title">Highest Bid</p>
          </div>
          <div className="values">
            <p className="value">50 TON (140 USD)</p>
            <p className="value">100 TON (300 USD)</p>
          </div>
        </div>
        <div className="dateBlock">
          <i class="fa-regular fa-clock"></i>
          <p className="date"> Sale ends on March 1st, 2023. at 4:38 AM</p>
        </div>
        <hr class="solid"></hr>
      </div>
    </div>
  );
};

export default Card;
