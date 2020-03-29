# **Unity_Tutorial Project**

## Introduction

유니티 각종 기능과 전체 프로젝트를 올립니다.
개인적인 프로젝트 또한 포함됩니다.

## Contents

- ###  **[Shooting Game Project]**

  - Gold Metal 유튜브 강좌를 보고 따라만든 게임입니다.
  - 총 `10`개의 스크립트로 구성되었습니다.
  - **주요기능**
    - **Object Pool 기능을 사용하여 미리 생성된 `오브젝트로 재활용`합니다.**
    - **Text를 읽어와 적 기체의 `스폰위치를 컨트롤`합니다.**
    - **조이 스틱 패널을 만들어 `모바일에서도 구동가능` 합니다.**
      - 조이 스틱은 `Event Trigger` 구동 방식입니다.
    - **무한 스크롤링 (스크롤링 & 패럴랙스) 구현했습니다.**
      - `원근감`있는 무한 스크롤 기법을 구현
    - **Boss 시스템**
      - 일정 패턴이 존재합니다.
      - 각 패턴은 sin, cos 함수를 이용하여 제작했습니다.
      - 패턴의 수를 정하여 Invoke 함수로 불러옵니다.

- ### **[2D Shader Graph Project]**

  - **2D Sprite Shape**
    - 2D의 오브젝트를 shape를 활용한 모양잡기
    - Tile map 과 다르게 굴곡과 유동성 있는 타일을 만들수 있음
  - **2D shader Graph**
    - 쉐이더 그래프를 이용한 클로킹 이펙트
    - Global Volume을 이용한 전체 볼륨 조정
    - 머테리얼을 이용한 클로킹 쉐이더
  - **2D Effectors**
    - Effect component의 기초 활용
      - Platform Effector : 특정한 범위(각)을 지정하여 효과를 줌
      - Surface Effector : X축 방향으로 힘을 줌 (부스트 효과, 급속적 힘의 방향)
      - Area Effector : y축 방향으로 힘을 줌 (공중부양, 특정 구간의 점프 힘)
      - Buoyancy Effector : 계속적인 바운스 효과 (통통 튀는 공, 바운스 게임 예시)
      - Point Effector : 특정 포인트에 힘을 줌 (행성의 중력, 더 큰 질량에 따라 오브젝트를 따라옴)  

- ### **[Line Project Project]**

  - Line component 를 이용한 마우스 그림 그리기
  - 그려진 Line은 동적으로 생성되고 Effector를 적용하여 각기 다른 힘을 받음
