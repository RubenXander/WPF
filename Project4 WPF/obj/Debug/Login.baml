   M S B A M L   `   `   `  ����G  CProject4 WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Project4_WPFProject4_WPF  5   	       Project4_WPF.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Project4_WPF     5   	     � Title$  Login��5   	   $	��450��6   $	��800��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��10 �6   6,   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��10 �6   6,    � RowDefinitions 5   
   �� 5      $��10 �6   6*   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��10 �6   6*   .+�5   
   �� $&�� /Images/PizzaBackgroundLogin.png��6   $��0��6:   $��7��6J   $��0��6^   $��7��6k   $
��Fill=�6|    J� Opacity$	 0.8Q�6�   6�   �� 5   
   $��2��6   $��2��6$   $��Center=�61   $��Center=�6N   $��Gebruikersnaam��6i   $��16(�6   
�������6�   �� 5    
   -   5         ��Name$ tbGebruikersnaam��5       $��2��6,   $��3��6<   $��2��6P   $��1��6]   $��Center=�6n   $��Bottom=�6�   $��20��6�   $	��400��6�   6�   �� 5"   
   $��2��6   $��3��6$   $��Center=�61   $��Center=�6N   $��
Wachtwoord��6i   $��16(�6{   
�������6�   �� 5#   
   -   5        $ tbWachtwoord��5#      $��2��6(   $��3��68   $��3��6L   $��1��6Y   $��Center=�6j   $��Bottom=�6�   $��20��6�   $	��400��6�   6�   �� 5%   
   -   5         ��Name$ btnLogin��5%      $��3��6#   $��4��63   $��40��6@   $	��100��6L   $��Login��6X   6�   5&      5'      