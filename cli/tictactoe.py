import typer
import os
import httpx
import json 

global url
global client
global sess_id

app = typer.Typer()
url="https://localhost:7205/api/v1/tictactoe/games"
client = httpx.Client(verify=False)
sess_id_file = ".session_id"

if os.path.exists(sess_id_file):
    with open(sess_id_file, "r") as f:
        sess_id = f.read().strip()

def update_session_id(sess_id):
    with open(sess_id_file, "w") as f:
        f.write(sess_id)

@app.command()
def start():
    res = client.post(url)
    data = res.json()
    print(f"Game initialized. Your session ID is: {data['session_id']}")
    update_session_id(data['session_id'])


@app.command()
def move(square: int):
    global url
    global sess_id
    full_url = f"{url}/{sess_id}/{square}"
    try:
        res = client.put(full_url)
        res.raise_for_status()
        data = res.json()
        print(json.dumps(data, indent=4))
        print("-------------------------------")
        prev_player = 'X' if data['current_player'] == 'O' else 'X'
        print(f"Player {prev_player} takes square {square}")
        for row in data['grid']:
            print(' '.join(row.replace('X', '✗').replace('O', '⭕')))
        if data['winning_player']:
            print(f"Player {data['winning_player']} wins!")
    except httpx.RequestError as exc:
        print(f"An error occurred while requesting {exc.request.url!r}.")
    except httpx.HTTPStatusError as exc:
        print(f"Error response {exc.response.status_code} while requesting {exc.request.url!r}.")



   
   

if __name__ == "__main__":
    app()
